using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{
    /*
     * Complete the 'optimalPoint' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY magic
     *  2. INTEGER_ARRAY dist
     */

    public static int optimalPoint(List<int> magic, List<int> dist)
    {
        var parameters = new commonParameters(magic, dist);

        if (parameters.magicLength > parameters.distanceLength)
        {
            prepareDistLength(parameters, dist);
        }

        // case border
        if (parameters.totalDistance > parameters.totalMagic)
        {
            return -1;
        }

        for (int index = 0; index < parameters.magicLength; index++)
        {
            var auxMagic = 0;
            var success = true;

            for (int i = 0; i < parameters.magicLength; i++)
            {
                var controlIndex = (index + i) % parameters.magicLength;

                auxMagic += magic[controlIndex];

                if (auxMagic >= dist[controlIndex])
                {
                    auxMagic -= dist[controlIndex];
                }
                else
                {
                    success = false;
                    break;
                }
            }
            if (success)
            {
                return index;
            }
        }
        return -1;
    }

    private static void prepareDistLength(commonParameters parameters, List<int> dist)
    {
        var diference = parameters.magicLength - parameters.distanceLength;

        for (int i = 0; i < diference; i++)
        {
            dist.Add(0);
        }
    }
}

public class commonParameters
{
    public int totalDistance { get; set; }
    public int totalMagic { get; set; }
    public int magicLength { get; set; }
    public int distanceLength { get; set; }

    public commonParameters(List<int> magic, List<int> dist)
    {
        this.totalDistance = dist.Sum();
        this.totalMagic = magic.Sum();
        this.magicLength = magic.Count();
        this.distanceLength = dist.Count();
    }
}

class Solution
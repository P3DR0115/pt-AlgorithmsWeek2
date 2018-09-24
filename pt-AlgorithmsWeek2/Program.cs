using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pt_AlgorithmsWeek2
{
    class Program
    {
        static void Main(string[] args)
        {
            globallyUniqueIdentifier();
            
            Console.WriteLine("Really Done! For Real (With sorting too) (The program is done running)!");
            Console.ReadKey();
        }

        static void globallyUniqueIdentifier()
        {
            List<DataSet> data = new List<DataSet>(); // The Original
            DataSet[] data2; // A copy to sort
            DataSet[] data3 = new DataSet[1000000]; // Another copy to sort
            string[] dataTemp = new string[1000000]; // A string copy that can be used to read/ write

            Random rnd = new Random(); // This is the random number
            //DataSet tempZ = new DataSet();
            int firstElement;     // This will be a counter in a loop
            Guid secondElement; // Will return the address of the element
            int thirdElement; // This will be the decimal in our data
            string temp;
            string temp2;

            //string[] data2 = data.ToArray();
            //string[] data3 = data2;

            try
            {
                loadFile(data, dataTemp);

                /*
                for(int i = 0; i < 1000000; i++)
                {
                    data.Add(data2[i]);
                }*/

                //mergeSort(data2, data3, data2.Length);
                //bubbleSort(data2, data3, data2.Length);
                data2 = data.ToArray();
            }
            catch (Exception e)
            {
                data.Clear();

                for (firstElement = 0; firstElement < 1000000; firstElement++)
                {
                    //secondElement = Guid.NewGuid();
                    thirdElement = rnd.Next(0, 10000000); // creating a random decimal
                    DataSet tempZ = new DataSet();
                    temp = "0.";
                    temp += thirdElement.ToString();

                    tempZ.decimalValue = 0;
                    tempZ.ID = Guid.NewGuid();

                    tempZ.decimalValue = Convert.ToDouble(temp);
                    //tempZ.ID = secondElement;

                    data.Add(tempZ);
                    //data.Insert(firstElement, tempZ);
                    

                    //data3[firstElement].ID = tempZ.ID;
                    //data3[firstElement].decimalValue = tempZ.decimalValue;


                    //temp2 = secondElement.ToString("X");
                    //temp2 = String.Format("{0:X}", secondElement);
                    //data.Add(temp2 + ", " + temp);
                    //data.Add(firstElement + ", " + secondElement + ", " + temp);

                    //Console.WriteLine( firstElement + ", " + data[firstElement]);
                    //Console.WriteLine(data[firstElement]);
                } // for loop end


                data2 = data.ToArray();
                Console.WriteLine("Done Making Numbers!");
                SaveFile(data2, dataTemp);

            } // Catch

            data2 = data.ToArray();
            data3 = data2;
            //SaveFile(data2, dataTemp);

            //data3 = data2;

            //insertionSort(data);

            //mergeSort(data2, data3, data2.Length);
            bubbleSort(data2, data3, data2.Length);

            
            SaveFileBubble(data2, dataTemp);
        } // Function()

        static void insertionPrototype()
        {

            /*for(int f = 0; f < length; f++) // Outer Loop
            {
                bit = data2[f].ID.ToByteArray();

                half = "";
                tmp3 = String.Format("{0:X}", tmp1);
                hex1 = Convert.ToDecimal(tmp3);

                try
                {
                    bit = data2[w + 1].ID.ToByteArray();
                }
                catch (Exception e)
                {
                    // Hit end of the array
                }

                for (int c = 0; c < length; c++) // Inner loop
                {

                    bit = data2[c].ID.ToByteArray();
                    for (int q = 0; q < (bit.Length / 2); q++)
                    {
                        half += Convert.ToString(bit[q]);
                    }

                    tmp1 = half;

                    for (int q = 0; q < (bit.Length / 2); q++)
                    {
                        half += Convert.ToString(bit[q]);
                    }

                    tmp2 = half;
                    half = "";
                    tmp3 = String.Format("{0:X}", tmp2);
                    hex2 = Convert.ToDecimal(tmp3);


                    if (hex1 < hex2)
                    {
                        // Do nothing, two numbers already sorted
                    }
                    else
                    {
                        sorted = false; // not sorted
                        try
                        {
                            bTrans = data2[w + 1]; // Assign the bTrans variable to avoid data loss first
                            data2[w + 1] = data2[w];
                            data2[w] = bTrans;
                            //Console.WriteLine("Switched " + w + " and " + (w+1) + " in the dataSet");
                        }
                        catch (Exception e)
                        {
                            // Hit limit of array
                        }
                    } // Else
                } // inner loop
            } */ // outer loop

        }

        static void SaveFile(DataSet[] data2, string[] dataTemp)
        {
            string tempString;

            for(int i = 0; i < data2.Length; i++)
            {
                tempString = Convert.ToString(data2[i].ID);
                tempString += ", ";
                tempString += Convert.ToString(data2[i].decimalValue);
                dataTemp[i] = tempString;
            }

            System.IO.File.WriteAllLines(@"C:\Users\P3dro\source\repos\Algorithms\pt-AlgorithmsWeek2\data.csv", dataTemp);
            Console.WriteLine("Done Saving to File");
        }

        static void SaveFileBubble(DataSet[] data2, string[] dataTemp)
        {
            string tempString;

            for (int i = 0; i < data2.Length; i++)
            {
                tempString = Convert.ToString(data2[i].ID);
                tempString += ", ";
                tempString += Convert.ToString(data2[i].decimalValue);
                dataTemp[i] = tempString;
            }

            System.IO.File.WriteAllLines(@"C:\Users\P3dro\source\repos\Algorithms\pt-AlgorithmsWeek2\dataBubbleSort.csv", dataTemp);
            Console.WriteLine("Done Saving to File (Bubble Sorted)");
        }

        static List<DataSet> loadFile(List<DataSet>data, string[] dataTemp)
        {

            dataTemp = System.IO.File.ReadAllLines(@"C:\Users\P3dro\source\repos\Algorithms\pt-AlgorithmsWeek2\data1.csv");
            Console.WriteLine("Load Complete!");
            string[] returnData = new string[1000000];
            string[] oneData;
            DataSet tempOne = new DataSet();
            Guid g;

            for (int i = 0; i < 1000000; i++)
            {
                oneData = dataTemp[i].Split(',');

                if(oneData[0] != "")
                {
                    //String.Format("{0:X}", oneData[0])
                    g = new Guid(oneData[0]);
                    tempOne.ID = g;
                    tempOne.decimalValue = Convert.ToDouble(oneData[1]);

                    data.Add(tempOne);
                }
            }

            return data;
        }

        public static void bubbleSort(DataSet[] data2, DataSet[] data3, int length)
        {
            DataSet bTrans; // Used to transition for the bubble sort
            decimal hex1 = 0; // Will be used to compare values
            decimal hex2 = 0;
            int iterations = 1;
            string tmp1;
            string tmp2;
            string tmp3;
            string half = "";
            byte[] bit;
            bool sorted = true;

            do // Bubble Sort
            {
                if(iterations%5 == 0 || iterations == 1)
                    Console.WriteLine("Iteration: " + iterations);

                //iterations++;

                sorted = true; // Assume it is sorted before the loop commences
                for (int w = 0; w < length; w++)
                {
                    bit = data2[w].ID.ToByteArray();
                    for (int q = 0; q < (bit.Length / 2); q++)
                    {
                        half += Convert.ToString(bit[q]);
                    }

                    tmp1 = half;
                    half = "";
                    tmp3 = String.Format("{0:X}", tmp1);
                    hex1 = Convert.ToDecimal(tmp3);

                    try
                    {
                        bit = data2[w + 1].ID.ToByteArray();
                    }
                    catch (Exception e)
                    {
                        // Hit end of the array
                    }

                    for (int q = 0; q < (bit.Length / 2); q++)
                    {
                        half += Convert.ToString(bit[q]);
                    }

                    tmp2 = half;
                    half = "";
                    tmp3 = String.Format("{0:X}", tmp2);
                    hex2 = Convert.ToDecimal(tmp3);

                    //tmp3 = String.Format("{0:X}", tmp1);
                    //hex1 = Convert.ToDecimal(data2[w].ID.ToByteArray());
                    //hex2 = Convert.ToDecimal(data2[(w+1)].ID.ToByteArray());

                    if (hex1 < hex2)
                    {
                        // Do nothing, two numbers already sorted
                    }
                    else
                    {
                        sorted = false; // not sorted
                        try
                        {
                            bTrans = data2[w + 1]; // Assign the bTrans variable to avoid data loss first
                            data2[w + 1] = data2[w];
                            data2[w] = bTrans;
                            //Console.WriteLine("Switched " + w + " and " + (w+1) + " in the dataSet");
                        }
                        catch (Exception e)
                        {
                            // Hit limit of array
                        }
                    } // Else

                } // for(w)
            } while (!sorted && iterations <= 9000);
            
        } // BubbleSort() end


        //I used https://en.wikipedia.org/wiki/Merge_sort for help with the merge sort
        static void mergeSort(string[] nums1, string[] nums2, int length) 
        {
            copyTheArray(nums1, 0, length, nums2);
            splitMerge(nums2, 0, length, nums1);
            System.IO.File.WriteAllLines(@"C:\Users\P3dro\source\repos\Algorithms\pt-AlgorithmsWeek2\dataMergeSort.csv", nums1);
        }

        static void copyTheArray(string[] iA, int iStart, int iStop, string[] iB)
        {
            for(int j = iStart; j < iStop; j++)
            {
                iB[j] = iA[j];
            }
        }

        static void splitMerge(string[] nums2, int iStart, int iStop, string[] nums1)
        {
            if(iStop - iStart < 2)
                return;

            int iMiddle = (iStop + iStart) / 2;

            splitMerge(nums1, iStart, iMiddle, nums2);
            splitMerge(nums1, iMiddle, iStop, nums2);
            topMerge(nums2, iStart, iMiddle, iStop, nums1);

        }

        static void topMerge(string[] nums1, int iStart, int iMiddle, int iStop, string[] nums2)
        {
            int i = iStart;
            int j = iMiddle;

            //char[] nums1Char;
            //char[] nums2Char;
            uint num1;
            uint num2;

            //bool lessThan = false;

            

            for(int k = iStart; k < iStart; k++)
            {
                num1 = uint.Parse(nums1[k], System.Globalization.NumberStyles.AllowHexSpecifier);
                num2 = uint.Parse(nums1[k+1], System.Globalization.NumberStyles.AllowHexSpecifier);

                /*if (num1 < num2)
                {
                    lessThan = true;
                }
                else
                    lessThan = false;*/

                //nums1Char = nums1[i].ToCharArray();
                //nums2Char = nums1[j].ToCharArray();

                /*for(int a = 0; a < nums1Char.Length; a++)
                {
                    if((nums1Char[a]) <= nums2Char[a] && a > 0)
                    {
                        // nums1 is still before nums2
                        lessThan = true;
                    }
                    else
                    {
                        // nums1 is no longer less than nums 2
                        lessThan = false;

                        if(a != 0)
                        {
                            //lessThan = true;
                        }

                    }
                }                
            */
                //if (i < iMiddle && (j >= iStop || lessThan))
                if (i < iMiddle && (j >= iStop || num1 <= num2))
                {
                    nums2[k] = nums1[k];
                    i += 1;
                }
                else
                {
                    nums2[k] = nums1[j];
                    j += 1;
                }

                //lessThan = false;
            }
        }
    }
}

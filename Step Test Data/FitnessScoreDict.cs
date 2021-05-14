using System;
using System.Collections.Generic;


namespace Step_Test_Data
{
    public static class FitnessScoreDict
    {

        public static Rating ComputeRatingFromScore(int score, int age, bool isFemale)
        {
            try
            {
                if (!isFemale)
                {
                    Tuple<int, int> AGEtuple;

                    foreach (Tuple<int, int> tuple in maleTable.Keys)
                    {
                        if (tuple.Item1 <= age && tuple.Item2 >= age)
                        {
                            AGEtuple = tuple;
                            foreach (Tuple<int, int> Stuple in maleTable[AGEtuple].Keys)
                            {
                                if (Stuple.Item1 <= age && Stuple.Item2 >= age)
                                {
                                    return maleTable[AGEtuple][Stuple];
                                }
                            }
                        }
                    }
                }
                else
                {
                    Tuple<int, int> AGEtuple;

                    foreach (Tuple<int, int> tuple in femaleTable.Keys)
                    {
                        if (tuple.Item1 <= age && tuple.Item2 >= age)
                        {
                            AGEtuple = tuple;
                            foreach (Tuple<int, int> Stuple in femaleTable[AGEtuple].Keys)
                            {
                                if (Stuple.Item1 <= age && Stuple.Item2 >= age)
                                {
                                    return femaleTable[AGEtuple][Stuple];
                                }
                            }
                        }
                    }
                }
                return Rating.Unknown;
            }
            catch
            {
                return Rating.Unknown;
            }
        }


        public static readonly Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, Rating>> femaleTable = new Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, Rating>>()
        {
            {
                new Tuple<int,int>(15, 19), new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(55, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(44, 54),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(36, 43),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(29, 35),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 29),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(20, 29),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(50, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(40, 49),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(32, 39),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(27, 31),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 27),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(30, 39),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(46, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(36, 45),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(30, 35),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(25, 29),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 25),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(40, 49),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(43, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(34, 42),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(28, 33),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(22, 27),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 22),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(50, 59),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(41, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(33, 40),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(26, 32),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(21, 25),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 21),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(60, 69),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(39, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(31, 38),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(24, 30),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(19, 23),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 19),
                        Rating.Poor
                    }
                }
            }
        };

        public static readonly Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, Rating>> maleTable = new Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, Rating>>()
        {
            {
                new Tuple<int,int>(15, 19), new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(60, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(58, 59),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(39, 47),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(30, 38),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 29),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(20, 29),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(55, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(44, 54),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(35, 43),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(28, 34),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 28),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(30, 39),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(50, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(40, 49),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(34, 39),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(26, 33),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 26),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(40, 49),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(46, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(37, 45),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(32, 36),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(25, 31),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 25),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(50, 59),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(44, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(35, 43),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(29, 34),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(23, 28),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 23),
                        Rating.Poor
                    }
                }
            },
            {
                new Tuple<int,int>(60, 69),
                new Dictionary<Tuple<int,int>, Rating>()
                {
                    {
                        new Tuple<int,int>(40, 76),
                        Rating.Excellent
                    },
                    {
                        new Tuple<int,int>(33, 39),
                        Rating.Good
                    },
                    {
                        new Tuple<int,int>(25, 32),
                        Rating.Average
                    },
                    {
                        new Tuple<int,int>(20, 24),
                        Rating.BelowAverage
                    },
                    {
                        new Tuple<int,int>(10, 20),
                        Rating.Poor
                    }
                }
            }
        };
    }

    public enum Rating
    {
        Excellent,
        Good,
        Average,
        BelowAverage,
        Poor,
        Unknown
    }
}


using System;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace LabLib
{
	public static class Extensions
	{
		public static DenseMatrix SelectColumns (this DenseMatrix mtx, IEnumerable<int> indexes)
		{
			var cols = new List<DenseVector> ();
			foreach (int index in indexes) {
				cols.Add ((DenseVector)mtx.Column (index));
			}
			return DenseMatrix.OfColumns (cols [0].Count, cols.Count, cols);
		}

		public static DenseMatrix SelectRows (this DenseMatrix mtx, IEnumerable<int> indexes)
		{
			var rows = new List<DenseVector> ();
			foreach (int index in indexes) {
				rows.Add ((DenseVector)mtx.Row (index));
			}
			return DenseMatrix.OfRows (rows.Count, rows [0].Count, rows);
		}

		public static DenseVector Select (this DenseVector v, IEnumerable<int> indexes)
		{
			var cols = new List<double> ();
			foreach (int index in indexes) {
				cols.Add (v [index]);
			}
			return DenseVector.OfEnumerable (cols);
		}

		public static bool IsInteger (this DenseVector d)
		{
			foreach (var x in d)
				if (!x.IsInteger ())
					return false;
			return true;
		}

		public static bool IsInteger (this Double d)
		{
			return Math.Abs (Math.Round (d) - d) < 0.00001f;
		}

		public static double Frac (this Double d)
		{
			if (d.IsInteger ())
				return 0;
			return d - Math.Floor (d);
		}
	}
}


using NUnit.Framework;
using netTools;

namespace netToolsTests
{
    [TestFixture]
    public class Tests
    {
        private Solver _solver;
        [SetUp]
        public void SetUp()
        {
            _solver = new Solver();
        }
        [Test]
        public void SolveEquationQuadraticAbc()
        {
            double[] root = _solver.SolveEquation(1, 2, 1);
            Assert.AreEqual(root.Length, 1);
            Assert.AreEqual(root[0], -1);

            root = _solver.SolveEquation(5, -9, 4);
            Assert.AreEqual(root.Length, 2);
            Assert.AreEqual(root[0], 0.8);
            Assert.AreEqual(root[1], 1);

            root = _solver.SolveEquation(1, 2, 100);
            Assert.AreEqual(root.Length, 0);

        }

        [Test]
        public void SolveEquationQuadraticNoC()
        {
            double[] root = _solver.SolveEquation(1, 2, 0);
            Assert.AreEqual(root.Length, 2);
            Assert.AreEqual(root[0], -2.0);
            Assert.AreEqual(root[1], 0.0);
        }

        [Test]
        public void SolveEquationQuadraticNegativeNoC()
        {
            double[] root = _solver.SolveEquation(-6, 9, 0);
            Assert.AreEqual(root.Length, 2);
            Assert.AreEqual(root[0], 0);
            Assert.AreEqual(root[1], 1.5);
        }

        [Test]
        public void SolveEquationLinear()
        {
            double[] root = _solver.SolveEquation(0, 2, 2);
            Assert.AreEqual(root.Length, 1);
            Assert.AreEqual(root[0], -1);
        }

        [Test]
        public void SolveEquationQuadraticNoB()
        {
            double[] root = _solver.SolveEquation(1, 0, -4);
            Assert.AreEqual(root.Length, 2);
            Assert.AreEqual(root[0], -2);
            Assert.AreEqual(root[1], 2);

            root = _solver.SolveEquation(1, 0, 4);
            Assert.AreEqual(root.Length, 0);
        }

        [Test]
        public void SolveEquationInfinityRoot()
        {
            double[] root = _solver.SolveEquation(0, 0, 0);
            Assert.AreEqual(root.Length, 1);
            Assert.AreEqual(root[0], double.PositiveInfinity);
        }
        [Test]
        public void SolveEquationNaNRoot()
        {
            double[] root = _solver.SolveEquation(0, 1, 0);
            Assert.AreEqual(root.Length, 1);
            Assert.AreEqual(root[0], 0);

            root = _solver.SolveEquation(0, 0, 1);
            Assert.AreEqual(root.Length, 0);

            root = _solver.SolveEquation(10, 1, 1);
            Assert.AreEqual(root.Length, 0);
        }
    }
}
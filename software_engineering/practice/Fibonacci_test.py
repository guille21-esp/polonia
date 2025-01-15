import math
import unittest

def fibo(n):
    if not isinstance(n, int) or n<0:
        return "n has to be a positive integer"
    if n == 0:
        return 1
    if n == 1:
        return 1
    a, b = 1, 1
    for i in range(2, n + 1):
        a, b = b, a + b
    return b

class FiboTestFunction(unittest.TestCase):
    def test_1(self):
        self.assertEqual(fibo(0),1)
    def test_2(self):
        self.assertEqual(fibo(1),1)
    def test_3(self):
        self.assertEqual(fibo(2),2)
    def test_4(self):
        self.assertEqual(fibo(3),3)
    def test_5(self):
        self.assertEqual(fibo(4),5)
    def test_6(self):
        self.assertEqual(fibo(5),8)
    
if __name__ == '__main__':
    unittest.main()

    
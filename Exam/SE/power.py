import math
import unittest

def p(base, exp):
    if base == 0:
        return "base cant be 0"
    if exp == 0:
        return 1
    if exp > 0:
        result = base
        for i in range(1, exp):
            result = result*base
        return result
    if exp < 0:
        div = base
        for i in range(1, abs(exp)):
            div = div*base
        result = 1/div
        return result
    else:
        return "not valid"

class Test_p(unittest.TestCase):
    def test_1(self):
        self.assertEqual(p(2,3),8)
    def test_2(self):
        self.assertEqual(p(2,-3),0.125)
    def test_3(self):
        self.assertEqual(p(0,5),"base cant be 0")
    
    
if __name__ == "__main__":
    unittest.main()

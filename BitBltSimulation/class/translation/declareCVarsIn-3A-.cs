declareCVarsIn: aCCodeGenerator
	aCCodeGenerator var: 'opTable'
		declareC: 'int opTable[' , OpTableSize printString , ']'.
	aCCodeGenerator var: 'maskTable'
		declareC:'int maskTable[33] = {
0, 1, 3, 0, 15, 31, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 65535,
0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1
}'.
	aCCodeGenerator var: 'ditherMatrix4x4'
		declareC:'const int ditherMatrix4x4[16] = {
0,	8,	2,	10,
12,	4,	14,	6,
3,	11,	1,	9,
15,	7,	13,	5
}'.
	aCCodeGenerator var: 'ditherThresholds16'
		declareC:'const int ditherThresholds16[8] = { 0, 2, 4, 6, 8, 12, 14, 16 }'.
	aCCodeGenerator var: 'ditherValues16'
		declareC:'const int ditherValues16[32] = {
0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
}'.

	aCCodeGenerator var: 'warpBitShiftTable'
		declareC:'int warpBitShiftTable[32]'.

	aCCodeGenerator var:'cmShiftTable' 
		declareC:'int *cmShiftTable'.
	aCCodeGenerator var:'cmMaskTable' 
		declareC:'unsigned int *cmMaskTable'.
	aCCodeGenerator var:'cmLookupTable' 
		declareC:'unsigned int *cmLookupTable'.

	aCCodeGenerator var: 'dither8Lookup'
		declareC:' unsigned char dither8Lookup[4096]'.

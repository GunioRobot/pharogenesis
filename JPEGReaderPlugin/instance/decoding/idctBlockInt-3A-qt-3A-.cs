idctBlockInt: anArray qt: qt
	| ws anACTerm dcval z2 z3 z1 t2 t3 t0 t1 t10 t13 t11 t12 z4 z5 v |
	self var: #anArray type:'int *'.
	self var: #qt type:'int *'.
	self var: #ws declareC:'int ws[64]'.
	self cCode:'' inSmalltalk:[ws _ CArrayAccessor on: (IntegerArray new: 64)].
	"Pass 1: process columns from anArray, store into work array"
	0 to: DCTSize-1 do:[:i |
		anACTerm _ -1.
		1 to: DCTSize-1 do:[:row|
			anACTerm = -1 ifTrue:[
				(anArray at: row * DCTSize + i) = 0 ifFalse:[anACTerm _ row]]].
		anACTerm = -1 ifTrue:[
			dcval _ (anArray at: i) * (qt at: 0) bitShift: Pass1Bits.
			0 to: DCTSize-1 do: [:j | ws at: (j * DCTSize + i) put: dcval]
		] ifFalse:[
			z2 _ (anArray at: (DCTSize * 2 + i)) * (qt at: (DCTSize * 2 + i)).
			z3 _ (anArray at: (DCTSize * 6 + i)) * (qt at: (DCTSize * 6 + i)).
			z1 _ (z2 + z3) * FIXn0n541196100.
			t2 _ z1 + (z3 * (0 - FIXn1n847759065)).
			t3 _ z1 + (z2 * FIXn0n765366865).
			z2 _ (anArray at: i) * (qt at: i).
			z3 _ (anArray at: (DCTSize * 4 + i)) * (qt at: (DCTSize * 4 + i)).
			t0 _ (z2 + z3) bitShift: ConstBits.
			t1 _ (z2 - z3) bitShift: ConstBits.
			t10 _ t0 + t3.
			t13 _ t0 - t3.
			t11 _ t1 + t2.
			t12 _ t1 - t2.
			t0 _ (anArray at: (DCTSize * 7 + i)) * (qt at: (DCTSize * 7 + i)).
			t1 _ (anArray at: (DCTSize * 5 + i)) * (qt at: (DCTSize * 5 + i)).
			t2 _ (anArray at: (DCTSize * 3 + i)) * (qt at: (DCTSize * 3 + i)).
			t3 _ (anArray at: (DCTSize + i)) * (qt at: (DCTSize + i)).
			z1 _ t0 + t3.
			z2 _ t1 + t2.
			z3 _ t0 + t2.
			z4 _ t1 + t3.
			z5 _ (z3 + z4) * FIXn1n175875602.
			t0 _ t0 * FIXn0n298631336.
			t1 _ t1 * FIXn2n053119869.
			t2 _ t2 * FIXn3n072711026.
			t3 _ t3 * FIXn1n501321110.
			z1 _ z1 * (0 - FIXn0n899976223).
			z2 _ z2 * (0 - FIXn2n562915447).
			z3 _ z3 * (0 - FIXn1n961570560).
			z4 _ z4 * (0 - FIXn0n390180644).
			z3 _ z3 + z5.
			z4 _ z4 + z5.
			t0 _ t0 + z1 + z3.
			t1 _ t1 +z2 +z4.
			t2 _ t2 + z2 + z3.
			t3 _ t3 + z1 + z4.
			ws at: i put: (t10 + t3) // Pass1Div.
			ws at: (DCTSize * 7 + i) put: (t10 - t3) // Pass1Div.
			ws at: (DCTSize * 1 + i) put: (t11 + t2) // Pass1Div.
			ws at: (DCTSize * 6 + i) put: (t11 - t2) // Pass1Div.
			ws at: (DCTSize * 2 + i) put: (t12 + t1) // Pass1Div.
			ws at: (DCTSize * 5 + i) put: (t12 - t1) // Pass1Div.
			ws at: (DCTSize * 3 + i) put: (t13 + t0) // Pass1Div.
			ws at: (DCTSize * 4 + i) put: (t13 - t0) // Pass1Div]].

	"Pass 2: process rows from work array, store back into anArray"
	0 to: DCTSize2-DCTSize by: DCTSize do:[:i |
		z2 _ ws at: i + 2.
		z3 _ ws at: i + 6.
		z1 _ (z2 + z3) * FIXn0n541196100.
		t2 _ z1 + (z3 * (0-FIXn1n847759065)).
		t3 _ z1 + (z2 * FIXn0n765366865).
		t0 _ (ws at: i) + (ws at: (i + 4)) bitShift: ConstBits.
		t1 _ (ws at: i) - (ws at: (i + 4)) bitShift: ConstBits.
		t10 _ t0 + t3.
		t13 _ t0 - t3.
		t11 _ t1 + t2.
		t12 _ t1 -t2.
		t0 _ ws at: (i + 7).
		t1 _ ws at: (i + 5).
		t2 _ ws at: (i + 3).
		t3 _ ws at: (i + 1).
		z1 _ t0 + t3.
		z2 _ t1 + t2.
		z3 _ t0 + t2.
		z4 _ t1 + t3.
		z5 _ (z3 + z4) * FIXn1n175875602.
		t0 _ t0 * FIXn0n298631336.
		t1 _ t1 * FIXn2n053119869.
		t2 _ t2 * FIXn3n072711026.
		t3 _ t3 * FIXn1n501321110.
		z1 _ z1 * (0-FIXn0n899976223).
		z2 _ z2 * (0-FIXn2n562915447).
		z3 _ z3 * (0-FIXn1n961570560).
		z4 _ z4 * (0-FIXn0n390180644).
		z3 _ z3 + z5.
		z4 _ z4 + z5.
		t0 _ t0 + z1 + z3.
		t1 _ t1 + z2 + z4.
		t2 _ t2 + z2 + z3.
		t3 _ t3 + z1 + z4.
		v _ (t10 + t3) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: i put: v.
		v _ (t10 - t3) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 7) put: v.
		v _ (t11 + t2) // Pass2Div + SampleOffset. 
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 1) put: v.
		v _ (t11 - t2) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 6) put: v.
		v _  (t12 + t1) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 2) put: v.
		v _  (t12 - t1) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 5) put: v.
		v _ (t13 + t0) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 3) put: v.
		v _ (t13 - t0) // Pass2Div + SampleOffset.
		v _ v min: MaxSample. v _ v max: 0.
		anArray at: (i + 4) put: v].
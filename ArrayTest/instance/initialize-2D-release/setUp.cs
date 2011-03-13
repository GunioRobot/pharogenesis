setUp

	literalArray := #(1 true 3 #four).
	selfEvaluatingArray := { 1. true. (3/4). Color black. (2 to: 4) . 5 }.
	nonSEArray1 := { 1 . Set with: 1 }.
	nonSEarray2 := { Smalltalk associationAt: #Array }.
	example1 := #(1 2 3 4 5).
	example2 := {1. 2. 3/4. 4. 5}. 
test
	| n |
	stream cr; cr; nextPutAll: 'Testing LargeIntegers computations...'.
	stream cr; tab; nextPutAll: 'operation symbols shown; ''0'' stands for (avoided) division by ''0'''; cr.
	self class name , ': performing arithmetic operations...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: oc1 size
		during: 
			[:bar | 
			n _ 0.
			oc1 with: oc2 do: 
				[:e1 :e2 | 
				bar value: (n _ n + 1).
				self
					computeOp: #+
					with: e1
					with: e2.
				self
					computeOp: #-
					with: e1
					with: e2.
				self
					computeOp: #*
					with: e1
					with: e2.
				self
					computeOp: #bitAnd:
					with: e1
					with: e2.
				self
					computeOp: #bitOr:
					with: e1
					with: e2.
				self
					computeOp: #bitXor:
					with: e1
					with: e2.
				e2 ~= 0
					ifTrue: [self
							computeOp: #/
							with: e1
							with: e2]
					ifFalse: [stream nextPutAll: ' 0 ']]].
	self class name , ': performing shift operations...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: ocShift size
		during: 
			[:bar | 
			n _ 0.
			ocShift with: ocShift2 do: 
				[:e1 :e2 | 
				bar value: (n _ n + 1).
				self
					computeOp: #bitShift:
					with: e1
					with: e2]]
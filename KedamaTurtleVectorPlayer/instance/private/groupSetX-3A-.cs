groupSetX: val

	| xArray headingArray origX origHeading leftEdgeMode rightEdgeMode newArray wrapX minX maxX |
	self size = 0 ifTrue: [^ self].
	xArray _ arrays at: 2.
	headingArray _ arrays at: 4.
	
	origX _ xArray first.
	origHeading _ headingArray first.

	leftEdgeMode _ kedamaWorld leftEdgeModeMnemonic.
	rightEdgeMode _ kedamaWorld rightEdgeModeMnemonic.

	newArray _ xArray collect: [:e | e + val - origX].
	wrapX _ kedamaWorld wrapX.
	minX _ newArray min.
	maxX _ newArray max.
	((minX < 0.0) not and: [(maxX >= wrapX) not]) ifTrue: [
		arrays at: 2 put: newArray.
		^ self.
	].

	minX < 0.0 ifTrue: [
		leftEdgeMode = 1 ifTrue: [
			newArray withIndexDo: [:e :i |
				e < 0.0 ifTrue: [newArray at: i put: e + wrapX].
			].
		].
		leftEdgeMode = 2 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e - minX.
			].
		].
		leftEdgeMode = 3 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e + (minX * -2.0).
			].
		].		
	].

	maxX >= wrapX ifTrue: [
		rightEdgeMode = 1 ifTrue: [
			newArray withIndexDo: [:e :i |
				e >= wrapX ifTrue: [newArray at: i put: e - wrapX].
			].
		].
		rightEdgeMode = 2 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e - (maxX - wrapX) - 2.35099e-038.
			].
		].
		rightEdgeMode = 3 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e - ((maxX - wrapX) * 2.0) - 2.35099e-038.
			].
		].
	].

	arrays at: 2 put: newArray.

groupSetY: val

	| yArray headingArray origY origHeading topEdgeMode bottomEdgeMode newArray wrapY minY maxY |
	self size = 0 ifTrue: [^ self].
	yArray _ arrays at: 3.
	headingArray _ arrays at: 4.
	
	origY _ yArray first.
	origHeading _ headingArray first.

	topEdgeMode _ kedamaWorld topEdgeModeMnemonic.
	bottomEdgeMode _ kedamaWorld bottomEdgeModeMnemonic.

	newArray _ yArray collect: [:e | e + val - origY].
	wrapY _ kedamaWorld wrapY.
	minY _ newArray min.
	maxY _ newArray max.
	((minY < 0.0) not and: [(maxY >= wrapY) not]) ifTrue: [
		arrays at: 3 put: newArray.
		^ self.
	].

	minY < 0.0 ifTrue: [
		topEdgeMode = 1 ifTrue: [
			newArray withIndexDo: [:e :i |
				e < 0.0 ifTrue: [newArray at: i put: e + wrapY].
			].
		].
		topEdgeMode = 2 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e - minY.
			].
		].
		topEdgeMode = 3 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e + (minY * -2.0).
			].
		].		
	].

	maxY >= wrapY ifTrue: [
		bottomEdgeMode = 1 ifTrue: [
			newArray withIndexDo: [:e :i |
				e >= wrapY ifTrue: [newArray at: i put: e - wrapY].
			].
		].
		bottomEdgeMode = 2 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e - (maxY - wrapY) - 2.35099e-038.
			].
		].
		bottomEdgeMode = 3 ifTrue: [
			newArray withIndexDo: [:e :i |
				newArray at: i put: e - ((maxY - wrapY) * 2.0) - 2.35099e-038.
			].
		].
	].

	arrays at: 3 put: newArray.

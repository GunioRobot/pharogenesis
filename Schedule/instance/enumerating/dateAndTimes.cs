dateAndTimes

	| dateAndTimes |
	dateAndTimes _ OrderedCollection new.
	self scheduleDo: [ :e | dateAndTimes add: e ].
	^ dateAndTimes asArray.
update: aParameter 

	|state|
	getLabelSelector ifNotNil: [
		aParameter == getLabelSelector ifTrue: [
			(self labelMorph respondsTo: #font)
				ifTrue: [self label: (model perform: getLabelSelector) font: self labelMorph font]
				ifFalse: [self label: (model perform: getLabelSelector)]]].
	state := self getModelState.
	(state ~= (self valueOfProperty: #lastState) or: [
	getStateSelector isNil and: [aParameter == #onOffColor]])
		ifTrue: [self color: self colorToUse.
				self setProperty: #lastState toValue: state]
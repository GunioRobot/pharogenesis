dispatch: argument on: aKey in: aTable ifNone: exceptionBlock
	| selector |
	(aKey < 1 or:[aKey > aTable size]) ifTrue:[^exceptionBlock value].
	selector := aTable at: aKey.
	^self perform: selector with: argument
findMessage
	"Control the search."

	data do: [:alist |
		(alist isKindOf: SequenceableCollection) ifFalse: [
			^ 'first and third items are not Arrays']].
	Approved ifNil: [self initialize].	"Sets of allowed selectors"
	expressions _ WriteStream on: (String new: 400).
	self search: true.	"multi"
	selector isEmpty ifTrue: [^ 'no single method does that function'].
 	^ expressions contents 
addJumpBeginning

	| ed attribute jumpEnd mySelection a1 ax |

	ed _ self editor.
	(mySelection _ ed selection) isEmpty ifTrue: [^self inform: 'Please select something first'].
	jumpEnd _ self chooseOneJumpEnd.
	jumpEnd isEmptyOrNil ifTrue: [^self].

	attribute _ TextPlusJumpStart new jumpLabel: jumpEnd.
	a1 _ (mySelection attributesAt: 1) reject: [ :each | each isKindOf: TextPlusJumpStart].
	ax _ (mySelection attributesAt: mySelection size) reject: [ :each | each isKindOf: TextPlusJumpStart].
	ed replaceSelectionWith: 
		(Text string: '*' attributes: a1),
		(mySelection addAttribute: attribute),
		(Text string: '*' attributes: ax).
	self releaseParagraphReally.
	self layoutChanged.


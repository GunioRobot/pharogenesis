form: aForm
	"Set the receiver's form"

	| oldForm topRenderer |
	oldForm _ originalForm.
	(self hasProperty: #baseGraphic) ifFalse: [self setProperty: #baseGraphic toValue: aForm].
	originalForm _ aForm.
	self rotationCenter: 0.5@0.5.
	self layoutChanged.
	topRenderer _ self topRendererOrSelf.

	oldForm ifNotNil: [topRenderer position: topRenderer position + (oldForm extent - aForm extent // 2)].

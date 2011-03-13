scopeHas: varName ifTrue: aBlock
	"Obsolete. Kept around for possible spurios senders which we don't know about"
	self deprecated: 'Obsolete'.
	(self bindingOf: varName) ifNotNilDo:[:binding|
		aBlock value: binding.
		^true].
	^false
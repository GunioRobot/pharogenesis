convertAugust1998: varDict using: smartRefStrm
	"These variables are automatically stored into the new instance ('bounds' 'owner' 'submorphs' 'fullBounds' 'color' ).
	This method is for additional changes. Use statements like (foo _ varDict at: 'foo')."

	"Be sure to to fill in ('extension' ) and deal with the information in ('eventHandler' 'properties' 'costumee' )"

"This method moves all property variables as well as eventHandler, and costumee into a morphicExtension."
	| propVal |
	"Move refs to eventhandler and costumee into extension"
	(varDict at: 'eventHandler') == nil ifFalse: [self eventHandler: (varDict at: 'eventHandler')].
	(varDict at: 'costumee') == nil ifFalse: [self player: (varDict at: 'costumee')].
	(varDict at: 'properties') == nil ifFalse:
		[(varDict at: 'properties') keys do:
			[:key |  "Move property extensions into extension"
			propVal _ (varDict at: 'properties') at: key.
			propVal ifNotNil:
				[key == #possessive
				ifTrue: [propVal == true ifTrue: [self bePossessive]]
				ifFalse: [key ifNotNil: [
					self assureExtension.
					extension convertProperty: key toValue: propVal]]]].
			].

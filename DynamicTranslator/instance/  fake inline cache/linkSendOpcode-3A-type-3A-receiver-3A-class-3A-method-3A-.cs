linkSendOpcode: ip type: type receiver: rcvr class: rcvrClass method: tMeth
	"Rewrite the send opcode at ip.
	ip:		the address of the linked extension word.
	type:	0=short, 1=extended, 2=double-extended.
	class:	the receiver class for which the inline cache hits."

	"Note: the opcode itself is located at (ip - 4 - (type * 8))."

	| op addr sendType linkData ccIndex currentMethod |

	self assertAny: (addr _ 0).
	self assertAny: (sendType _ 0).

	(self isIntegerObject: rcvr)
		ifTrue: [sendType _ ImmediateSendType.  linkData _ ConstZero]
		ifFalse:
			[ccIndex _ ((self formatOfClass: rcvrClass) bitAnd: 16r1F000).
			 ccIndex > 0
				ifTrue: [sendType _ CompactSendType.  linkData _ ccIndex + 1]
				ifFalse: [sendType _ NormalSendType.  linkData _ rcvrClass]].

	self assert: (sendType ~= 0).

	type = ShortSendType	 		ifTrue:	[addr _ ip - 4.	op _ shortSendTable at: sendType]			ifFalse: [
	type = ExtendedSendType			ifTrue:	[addr _ ip - 12.	op _ extendedSendTable at: sendType]		ifFalse: [
	type = DoubleExtendedSendType	ifTrue:	[addr _ ip - 20.	op _ doubleExtendedSendTable at: sendType]	]].

	self assert: (addr ~= 0).

	self longAt: addr put: op.
	self longAt: ip put: tMeth.
	self storePointer: MethodLinkageIndex ofObject: tMeth withValue: linkData.

	tMeth >= youngStart ifTrue:		"store of young object into old object"
		[currentMethod _ self translatedMethod.
		 currentMethod < youngStart
			ifTrue: [self addMethodRoot: currentMethod]].

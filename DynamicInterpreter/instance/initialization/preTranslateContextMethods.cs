preTranslateContextMethods
	"Scan the object memory for MethodContexts, translating their methods and
	installing the results in their translatedMethod slot.  Note that there is one
	problematical MethodContext: that which was active for #snapshot:andQuit:
	when the image was saved.  This context has its root bit set, and so will not
	be placed in the root table when the translated method is stored into it.  We
	therefore remove any root bits that we find set in the method contexts for
	which new translated methods are generated."

	| oop header |
	self inline: false.
	oop _ self firstAccessibleObject.
	[oop = nil] whileFalse: [
		(self fetchClassOf: oop) = (self splObj: ClassMethodContext) ifTrue: [
			header _ self longAt: oop.
			(header bitAnd: RootBit) = 0 ifFalse: [self longAt: oop put: (header bitAnd: AllButRootBit)].
			newMethod _ self fetchPointer: MethodIndex ofObject: oop.
			(self fetchClassOf: newMethod) = (self splObj: ClassCompiledMethod) ifTrue: [
				self translateNewMethod.
				self assertIsTranslatedMethod: newTranslatedMethod.
				self storePointer: TranslatedMethodIndex ofObject: oop
					withValue: newTranslatedMethod.
			].
		].
		oop _ self accessibleObjectAfter: oop.
	].
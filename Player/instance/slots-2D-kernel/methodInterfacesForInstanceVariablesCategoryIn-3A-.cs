methodInterfacesForInstanceVariablesCategoryIn: aVocabulary
	"Return a collection of methodInterfaces for the instance-variables category.  The vocabulary parameter, at present anyway, is not used."

	| aList anInterface itsSlotName |
	aList _ OrderedCollection new.
	self slotInfo associationsDo:
		[:assoc |
			anInterface _ MethodInterface new.
			itsSlotName _ assoc key.
			anInterface
				wording: itsSlotName;
				helpMessage: 'a variable defined by this object' translated.

			anInterface selector: (Utilities getterSelectorFor: itsSlotName) type: assoc value type setter: (Utilities setterSelectorFor: itsSlotName).
			anInterface setToRefetch.
			aList add: anInterface].
	^ aList
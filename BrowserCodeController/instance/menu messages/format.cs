format
	"Reformat the contents of the receiver's view, formatted, if the view is unlocked. "

	| selectedClass aCompiler newText locked |
	locked _ model isLocked.
	Sensor leftShiftDown
		ifTrue: [self miniFormat]
		ifFalse: 
			[model messageListIndex = 0 | locked ifTrue: [^view flash].
			selectedClass _ model selectedClassOrMetaClass.
			Cursor execute showWhile: 
				[aCompiler _ selectedClass compilerClass new.
				self deselect; selectInvisiblyFrom: 1 to: paragraph text size.
				newText _ aCompiler
					format: model contents
					in: selectedClass
					notifying: self.
				newText == nil ifFalse: 
					[self replaceSelectionWith:
						(newText asText makeSelectorBoldIn: selectedClass).
					self selectAt: 1]]].
	locked ifFalse: [self unlockModel]
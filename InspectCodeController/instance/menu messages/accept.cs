accept

	| result |
	(model isUnlocked or: [model selectionUnmodifiable])
		ifTrue: [^view flash].
	self controlTerminate.
	result _ model doItReceiver class evaluatorClass new
				evaluate: (ReadStream on: paragraph string)
				in: model doItContext
				to: model doItReceiver
				notifying: self
				ifFail:  [self controlInitialize. ^nil].
	result == #failedDoit
		ifFalse: 
			[model replaceSelectionValue: result.
			self selectFrom: 1 to: paragraph text size.
			self deselect.
			self replaceSelectionWith: result printString asText.
			self selectAt: 1.
			super accept].
	self controlInitialize
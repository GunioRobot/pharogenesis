isSelected: aButton
	^ (buttons at: selection ifAbsent: [^ false]) == aButton
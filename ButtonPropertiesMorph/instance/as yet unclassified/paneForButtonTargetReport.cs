paneForButtonTargetReport

	| r |

	r _ self inARow: {
		self lockedString: 'Target: ' translated.
 		UpdatingStringMorph new
			useStringFormat;
			getSelector: #target;
			target: self targetProperties;
			growable: true;
			minimumWidth: 24;
			lock.
	}.
	r hResizing: #shrinkWrap.
	self allowDropsInto: r withIntent: #changeTargetTarget.
	r setBalloonText: 'Drop another morph here to change the target and action of this button. (Only some morphs will work)' translated.
	^self inARow: {r}



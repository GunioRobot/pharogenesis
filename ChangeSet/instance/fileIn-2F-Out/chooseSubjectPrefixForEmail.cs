chooseSubjectPrefixForEmail

	| subjectIndex |

	subjectIndex _
		(PopUpMenu labels: 'Bug fix [FIX]\Enhancement [ENH]\Goodie [GOODIE]\Test suite [TEST]\None of the above (will not be archived)' withCRs)
			startUpWithCaption: 'What type of change set\are you submitting to the list?' withCRs.

	^ #('[CS] ' '[FIX] ' '[ENH] ' '[GOODIE] ' '[TEST] ' '[CS] ') at: subjectIndex + 1
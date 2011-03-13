decideAboutCreatingBlank: otherProjectName

	| resp |

	"20 Oct - just do it"
	true "version isNil" ifFalse: [	"if saved, then maybe don't create"
		resp _ (PopUpMenu labels: 'Yes, make it up\No, skip it' withCRs) 
			startUpWithCaption: (
				'I cannot locate the project\',
				otherProjectName,
				'\Would you like me to create a new project\with that name?'
			) withCRs.
		resp = 1 ifFalse: [^ nil]
	].
	^Project openBlankProjectNamed: otherProjectName
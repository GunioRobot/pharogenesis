registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(Preferences	preferencesControlPanel	'Preferences'	'Allows you to control numerous options')
						forFlapNamed: 'Tools'.
						cl registerQuad: #(Preferences			annotationEditingWindow	'Annotations'		'Allows you to specify the annotations to be shown in the annotation panes of browsers, etc.')
						forFlapNamed: 'Tools'.]
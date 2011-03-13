applyToEditor: editor
	"the inform: is deferred, because otherwise the editor can stop stepping!"
	WorldState addDeferredUIMessage: [ editor inform: 'Error: ', description ]

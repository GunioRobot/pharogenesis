loaderUrl
	"Return a url that will allow to launch a project in a browser by composing a url like
	<loaderURL>?<projectURL>"

	^AbstractLauncher extractParameters at: 'LOADER_URL' ifAbsent: [nil].
process: request
	"Handle requests of the form {swikiname}.{coreRef}.render"
	(request message size > 2) ifTrue: [
		((request message at: 3) = 'render') ifTrue:
		[ self generate: (urlmap atID: (request message at: 2)).
		request reply: (PWS success) ; reply: (PWS contentHTML).
		^self browse: (urlmap atID: (request message at: 2)) from:
request].
		((request message at: 3) = 'html') ifTrue: "Handle 1.html refs"
		[^self browse: (urlmap atID: (request message at: 2)) from:
request]].
	super process: request.

mantisAction: line reportOn: report
	
	| param mantis |
	
	mantis := Installer mantis.
	
	param :=  line readStream upTo: $: ; upTo: $..
	
	mantis setBug: ((param readStream upTo: $'; atEnd)
		 ifTrue: [  param ]
		 ifFalse: [ param readStream upTo: $'; upTo: $' ]).
	
	self reportSection: line on: report.
		
	report nextPutAll: (mantis replaceEntitiesIn: mantis markersBegin readStream).
	
	self reportFor: line page: mantis maScript on: report.
	
	report nextPutAll: (mantis replaceEntitiesIn: mantis markersEnd readStream); cr.
	
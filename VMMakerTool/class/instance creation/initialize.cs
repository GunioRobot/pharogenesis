initialize

	 (TheWorldMenu respondsTo: #registerOpenCommand:)

         ifTrue: [TheWorldMenu registerOpenCommand: {'VMMaker'. {self. #openInWorld}. 'The VM making tool'}].
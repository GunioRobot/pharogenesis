methodChanged: event
	| cls | 
	self ifInteractiveDo: [
	cls := event itemClass. 
	((event changeKind = #removed) not & (cls inheritsFrom: ServiceProvider) and: [cls new services includes: event itemSelector])
		ifTrue: [[self current addService: (cls new performAndSetId: event itemSelector)
					provider: cls]
			on: Error do: [self inform: 'Service format seems to be incorrect']]]
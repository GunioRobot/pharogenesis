arrowKey: aChar from: view
	"Process the up and down arrows in a list pane.  Note that the listView tells us what index variable, how to get the list, and how to move the index.  Derived from a Martin Pammer submission, 02/98"

     | keyEvent oldSelection nextSelection max min howMany anEvent |

	(#(1 4 11 12 30 31) includes: (keyEvent _ aChar asciiValue)) ifFalse:
		[(Smalltalk isMorphic and: [false]) ifTrue:
			[((anEvent _ view currentEvent) isKindOf: KeyboardEvent) ifTrue: [self currentWorld keystrokeInWorld: anEvent]].
			self flag: #deferred.
			"Would like to pass all command-keys that pass through the hands of the model via this protocol but are not in fact interecepted here on to the desktop, where they might be quite relevant.  But when we obtain the event this way we are not getting the keyboard event"
			^ self].

     oldSelection := view getCurrentSelectionIndex.
     nextSelection := oldSelection.
     max := view maximumSelection.
     min := view minimumSelection.
     howMany := view numSelectionsInView.	"get this exactly??"

     keyEvent == 31 ifTrue:
		["down-arrow; move down one, wrapping to top if needed"
		nextSelection := oldSelection + 1.
		nextSelection > max ifTrue: [nextSelection _ 1]].

     keyEvent == 30 ifTrue:
		["up arrow; move up one, wrapping to bottom if needed"
		nextSelection := oldSelection - 1.
		nextSelection < 1 ifTrue: [nextSelection _ max]].

     keyEvent == 1  ifTrue: [nextSelection := 1].  "home"
     keyEvent == 4  ifTrue: [nextSelection := max].   "end"
     keyEvent == 11 ifTrue: [nextSelection := min max: (oldSelection - howMany)].  "page up"
     keyEvent == 12  ifTrue: [nextSelection := (oldSelection + howMany) min: max].  "page down"
     nextSelection = oldSelection  ifFalse:
		[self okToChange
			ifTrue:
				[view changeModelSelection: nextSelection.
				"view controller moveMarker"]]
			
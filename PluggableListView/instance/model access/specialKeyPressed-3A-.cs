specialKeyPressed: keyEvent
	"Process the up and down arrows in a list pane."
     | oldSelection nextSelection max min howMany |

	(#(1 4 11 12 30 31) includes: keyEvent) ifFalse: [ ^ false ].

     oldSelection := self getCurrentSelectionIndex.
     nextSelection := oldSelection.
     max := self maximumSelection.
     min := self minimumSelection.
     howMany := self numSelectionsInView.	"get this exactly??"

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
		[model okToChange
			ifTrue:
				[self changeModelSelection: nextSelection.
				"self controller moveMarker"]].
	
	^true
			
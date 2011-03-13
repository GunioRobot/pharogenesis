arrowKey: aChar from: view
	"Process the up and down arrows in a list pane.  Note that the listView tells us what index variable, how to get the list, and how to move the index.  Derived from a Martin Pammer submission, 02/98"
     | keyEvent oldSelection nextSelection max min howMany |

     (keyEvent := aChar asciiValue) > 31 ifTrue: [^ self].	"Quick return, out of range"
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
			
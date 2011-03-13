restore: aRectangle below: index without: aView
	"Restore all windows visible in aRectangle, but without aView"
	| view | 
	view := (scheduledControllers at: index) view.
	view == aView ifTrue: 
		[index >= scheduledControllers size ifTrue: [^ self].
		^ self restore: aRectangle below: index+1 without: aView].
	view displayOn: ((BitBlt current toForm: Display) clipRect: aRectangle).
	index >= scheduledControllers size ifTrue: [^ self].
	(aRectangle areasOutside: view windowBox) do:
		[:rect | self restore: rect below: index + 1 without: aView]
setLabelRegion
	"Always follows view width or label's text width"
	| aRect desiredWidth realWidth |
	aRect _ 0 @ 0 extent: 
		(self isCollapsed
			ifFalse: [
				desiredWidth _ labelText width + 70.
				realWidth _ self displayBox width.
				realWidth < desiredWidth ifTrue: [
					self window: self window viewport: 
						(self displayBox width: desiredWidth).
					realWidth _ desiredWidth].
				realWidth @ 18]  "width of window"
			ifTrue: [labelText extent x + 70 @ 19] "room for buttons"
			).
	labelFrame region: aRect.
	^ aRect
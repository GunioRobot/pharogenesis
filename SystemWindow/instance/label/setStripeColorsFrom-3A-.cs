setStripeColorsFrom: paneColor 
	"Set the stripe color based on the given paneColor"
	labelArea
		ifNotNil: [
			labelArea
				color: (Preferences alternativeWindowLook
						ifTrue: [paneColor lighter]
						ifFalse: [Color transparent])].
	
	self
		updateBoxesColor: (self isActive
				ifTrue: [paneColor]
				ifFalse: [paneColor muchDarker]).
	
	stripes
		ifNil: [^ self].
	
	Preferences alternativeWindowLook
		ifTrue: [
			self isActive
				ifTrue: [
					stripes first borderColor: paneColor paler;
						 color: stripes first borderColor slightlyLighter.
					stripes second borderColor: stripes first color slightlyLighter;
						 color: stripes second borderColor slightlyLighter]
				ifFalse: ["This could be much faster"
					stripes first borderColor: paneColor;
						 color: paneColor.
					stripes second borderColor: paneColor;
						 color: paneColor]]
		ifFalse: [
			self isActive
				ifTrue: [
					stripes second color: paneColor;
						 borderColor: stripes second color darker.
					stripes first color: stripes second borderColor darker;
						 borderColor: stripes first color darker]
				ifFalse: ["This could be much faster"
					stripes second color: paneColor;
						 borderColor: paneColor.
					stripes first color: paneColor;
						 borderColor: paneColor]]
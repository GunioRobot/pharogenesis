makeListeningToggle: withEars

	| background c capExtent bgExtent earExtent earDeltaX earDeltaY botCent factor parts |

	factor _ 2.
	bgExtent _ (50@25) * factor.
	capExtent _ (30@30) * factor.
	earExtent _ (15@15) * factor.
	earDeltaX _ capExtent x // 2.
	earDeltaY _ capExtent y // 2.
	background _ Form extent: bgExtent depth: 8.
	botCent _ background boundingBox bottomCenter.
	c _ background getCanvas.
	"c fillColor: Color white."
	parts _ {
		(botCent - (capExtent // 2)) extent: capExtent.
	}.
	withEars ifTrue: [
		parts _ parts , {
			(botCent - (earDeltaX @ earDeltaY) - (earExtent // 2)) extent: earExtent.
			(botCent - (earDeltaX negated @ earDeltaY) - (earExtent // 2)) extent: earExtent.
		} 
	].
	parts do: [ :each |
		c
			fillOval: each
			color: Color black 
			borderWidth: 0 
			borderColor: Color black.
	].
	^background

"=====
	f2 _ Form extent: 30@15 depth: 8.
	background displayInterpolatedOn: f2.
	f2 replaceColor: Color white withColor: Color transparent.
	^f2
====="


	
displayBordersAndLabels

	| labelOrigin barOrigin delta |
	Display fill: (window insetBy: Inset negated) fillColor: BorderColor.
	Display fill: (window insetBy: BorderWidth - Inset) fillColor: BackgroundColor.

	barOrigin _ window topRight translateBy: (BarWidth negated - (2 * BarBorderWidth))@0.
	labelOrigin _ barOrigin translateBy: (Inset negated)@"0"(BorderWidth - Inset).
	delta _ 0@baselineSkip.
	1 to: labels size do: [:index |
		(labels at: index) displayOn: Display at: (labelOrigin translateBy: ((labels at: index) width negated)@0).
		Display fill: (barOrigin extent: (BarWidth + (2 * BarBorderWidth))@baselineSkip)
			fillColor: BarBorderColor.
		labelOrigin _ labelOrigin translateBy: delta.
		barOrigin _ barOrigin translateBy: delta].
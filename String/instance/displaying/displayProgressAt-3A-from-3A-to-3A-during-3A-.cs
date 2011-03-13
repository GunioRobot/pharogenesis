displayProgressAt: aPoint from: minVal to: maxVal during: workBlock 
	"Display this string as a caption over a progress bar while workBlock is evaluated.

EXAMPLE (Select next 6 lines and Do It)
'Now here''s some Real Progress'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: 10
	during: [:bar |
	1 to: 10 do: [:x | bar value: x.
			(Delay forMilliseconds: 500) wait]].

HOW IT WORKS (Try this in any other language :-)
Since your code (the last 2 lines in the above example) is in a block,
this method gets control to display its heading before, and clean up 
the screen after, its execution.
The key, though, is that the block is supplied with an argument,
named 'bar' in the example, which will update the bar image every 
it is sent the message value: x, where x is in the from:to: range.
"
	| delta savedArea captionText textFrame barFrame outerFrame |
	barFrame _ aPoint - (75@10) corner: aPoint + (75@10).
	captionText _ DisplayText text: self asText allBold.
	textFrame _ captionText boundingBox insetBy: -4.
	textFrame _ textFrame align: textFrame bottomCenter
					with: barFrame topCenter + (0@2).
	outerFrame _ barFrame merge: textFrame.
	delta _ outerFrame amountToTranslateWithin: Display boundingBox.
	barFrame moveBy: delta.  textFrame moveBy: delta.  outerFrame moveBy: delta.
	savedArea _ Form fromDisplay: outerFrame.
	Display fillBlack: barFrame; fillWhite: (barFrame insetBy: 2).
	Display fillBlack: textFrame; fillWhite: (textFrame insetBy: 2).
	captionText displayOn: Display at: textFrame topLeft + (4@4).
	workBlock value:  "Supply the bar-update block for evaluation in the work block"
		[:barVal | Display fillGray: (barFrame topLeft + (2@2) extent:
					((barFrame width-4) * (barVal-minVal) /(maxVal - minVal)@16))].
	savedArea displayOn: Display at: outerFrame topLeft.

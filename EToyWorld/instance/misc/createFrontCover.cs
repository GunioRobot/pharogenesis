createFrontCover
	"Just one big cover picture"
	| tabHeight xcent imagi badge m walt generalHelp |
	"commented out for March 6 demo, jhm:
		[self scanServerForEToys] forkAt: Processor userInterruptPriority."

	tabHeight _ 20.
	generalHelp _ 
'Welcome to the Design Studio!  Enter your name
on the Imagineer badge and you''ll become an 
Honorary Imagineer.   To enter the studio and 
design a model or toy, select one of the choices
on the top.'.

	frontCover _ Morph new color: (InfiniteForm with: (ScriptingSystem formAtKey: 'CoverTexture')).
	frontCover bounds: self bounds.
	frontCover on: #mouseDown send: #yourself to: frontCover.

	xcent _ (bounds center x + 20) @ 0.  "shift right to account for spiral binding"
	imagi _ ImageMorph new image: (ScriptingSystem formAtKey: 'CoverMain').
	frontCover addMorph: imagi.
	imagi align: imagi bounds topCenter with: xcent.

	"add Alan's cleaned up 'Walt Disney' text"
	walt _ Morph new extent: 424@149.  "(formerly EToySystem formAtKey: 'WaltPic') extent "
	walt color: Color transparent.
	frontCover addMorph: walt.
	walt align: walt bounds topCenter with: xcent + EToyParameters waltPicPoint.
	walt setBalloonText: generalHelp.

	badge _ Morph new extent: (ScriptingSystem formAtKey: 'BadgePic') extent.
	badge color: Color transparent.
	frontCover addMorph: badge.
	badge align: badge bounds topCenter with: xcent + EToyParameters badgePicPt - (0@30).

	tabs _ MappedTabsMorph new.
	frontCover addMorph: tabs.
	tabs align: tabs bounds topLeft with: xcent + (-205@10).
	tabs extent: (tabs extent x @ tabHeight).

	userName ifNil: [userName _ 'Your Name Here'].
	
	m _ TextMorph new.
	m string: userName fontName: 'ComicBold' size: 36.
	frontCover addMorph: m.
	m extent: 200@60.
	m setProperty: #Transparent toValue: Color transparent.
	m beAllFont: (StrikeFont familyName: 'ComicBold' size: 36).
	m align: m center with: badge center + (0@30); fit; centered.
	m setBalloonText: 
'Select "Your Name Here"
and replace it with your
name. You''ll become an 
Honorary Imagineer!'.

	m _ SimpleButtonMorph new label: 'Exit'; color: Color lightRed;
		actionSelector: #exitFromCover; target: self.
	m  setBalloonText: 'Click here to exit the Design Studio.'.
	frontCover addMorphFront: m.
	m position: 40 @ (self height - 22).	"y of 458, parameterized"

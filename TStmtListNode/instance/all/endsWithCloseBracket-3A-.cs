endsWithCloseBracket: aStream
	"Answer true if the given stream ends in with $} character."
	| ch pos |
	(pos _ aStream position) > 0 ifTrue: [
		aStream position: pos - 1.
		ch _ aStream next.
		aStream position: pos.
	].
	^ ch = $}

" *** There's something wrong with File positioning.  If you execute the following code, it will print '(hello));;' , but it will give an error if you remove the line the says
	f position: f position.

 | f c p1 p2 p3 | 
f _ FileStream fileNamed: 'test'.
f nextPutAll: '(hello))'.
f position: (p1 _ f position)-1.
p2 _ f position.
c _ f next.
p3 _ f position.
f position: f position.
f nextPut: $;; nextPut: $;.
f close.
(FileStream fileNamed: 'test') contentsOfEntireFile
"
header
	"append the HTML header.  Be sure to call trailer after you put out the data.
	4/4/96 tk"
	| cr f |
	cr _ String with: Character cr.
	self command: 'HTML'; verbatim: cr.
	self command: 'HEAD'; verbatim: cr.
	self command: 'TITLE'.
	self nextPutAll: '"', self name, '"'.
	self command: '/TITLE'; verbatim: cr.
	self command: '/HEAD'; verbatim: cr.
	self command: 'BODY'; verbatim: cr.

	"Write out tab.gif because it is used when source code is written as html"
(StandardFileStream isAFileNamed: 'tab.gif') ifFalse: [
	f _ FileStream fileNamed: 'tab.gif'.
	f nextPutAll: 'GIF89a  �  ���   !�    ,      @��Y !�clip2gif v.0.4 by Yves Piguet ;'.
	f close].

asHtml
	"Do the basic character conversion for HTML.  Leave all original return 
	and tabs in place, so can conver back by simply removing bracked 
	things. 4/4/96 tk"
	| temp |
	temp _ self copyReplaceAll: '&' with: '&amp;'.
	HtmlEntities keysAndValuesDo:
		[:entity :char |
		char = $& ifFalse:
			[temp _ temp copyReplaceAll: char asString with: '&' , entity , ';']].
	temp _ temp copyReplaceAll: '	' with: '	<IMG SRC="tab.gif" ALT="    ">'.
	temp _ temp copyReplaceAll: '
' with: '
<BR>'.
	^ temp

"
	'A<&>B' asHtml
"
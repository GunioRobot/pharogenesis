recent
	| response sortedPages currentDate |
	sortedPages _ pages reject: [:page | page pageStatus = #new].
"We definitely want the reject: first, so we sort a smaller collection.
Having the variable name be 'sortedPages' is a bit of a misnomer, though."

"I think we shouldn't do all this for each call to recent changes. After
all, most of the time, it's *hasn't* changed, and when it *has*, it's
pretty much only added something to the end. At the very least we should
cache the sorted, filtered collection."

"And really, why is this in URLmap? Recent Changes is a kind of page. I'd
rather see it as a swikipage, perhaps standardly defined (that is, when you
set up a swiki, you get a front page, a formatting page, and a Recent
Changes page). That is, SwikiPages could store text (as they do now) or
cgi-ish functions (like recent). That way, we could design custom templates
for them, etc.

At the very least, there needs to be better labeling. Why not call the
category with these page functions, 'dynamic pages', or somethign similar?"

"A different condsideration: It would be nice to have arbitrary filters:
e.g., 'past ten days', 'all pages *not* yet edited', etc., and be able to
combine them. Would work as a 'search for various attributes' feature which
one might or might not expose to the user."
	sortedPages _ sortedPages asSortedCollection: [:a :b | (a date = b
date) ifTrue: [a time > b time]
			ifFalse: [a date > b date]].
	response _ WriteStream on: String new.
	response nextPutAll: '<h2>Recent Changes</h2><ul>'.
	currentDate _ Date new.
	sortedPages do: [:page |
		(currentDate ~= page date)
		ifTrue: [
			currentDate _ page date.
			response nextPutAll: '</ul><p><b>',(currentDate
printString),'</b><p><ul>'.].
		response nextPutAll: '<li>',(self pageURL: page),'...',(page
address).].
	response nextPutAll: '</ul>'.
	^response contents

		
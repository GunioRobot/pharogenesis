setUp
	
	super setUp.
	list := LinkedList new.
	link1 := Link new.
	link2 := Link new.
	link3 := Link new.
	link4 := Link new.
	elementNotIn := Link new.
	collectionWithoutNil := LinkedList new add: Link new; add: Link new ; add: Link new; yourself.
	elementIn := Link new.
	collectionWithoutEqualElements := LinkedList new add: elementIn ; add: Link new ; add: Link new; add: Link new;add: Link new;yourself.
	collection5Elements := collectionWithoutEqualElements .
	
	"sameAtendAndBegining := LinkedList new add: Link new; add: Link new ; add: Link new; yourself."
	result := {Link. Link. Link.}.
	link := StackLink with: 42.
	nonEmpty1Element :=  LinkedList new add: Link new; yourself.
	 "so that we can recognize this link"
	"nonEmpty := LinkedList with: link with: Link new."
	"otherList := LinkedList with: Link new with: Link new."

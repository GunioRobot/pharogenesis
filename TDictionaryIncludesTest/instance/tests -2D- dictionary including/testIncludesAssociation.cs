testIncludesAssociation

|  associationNotIn associationIn keyIn valueIn |

keyIn := self nonEmpty keys anyOne.
valueIn := self nonEmpty values anyOne. 
associationNotIn := self keyNotInNonEmpty -> self valueNotInNonEmpty .
associationIn := self nonEmpty associations anyOne.	

self assert:  (self nonEmpty includesAssociation: associationIn ).
self deny:  (self nonEmpty includesAssociation: associationNotIn ).
" testing the case where key is included but not with the same value :"
self deny: (self nonEmpty includesAssociation: (keyIn-> self valueNotInNonEmpty )).
" testing the case where value is included but not corresponding key :"
self deny: (self nonEmpty includesAssociation: (self keyNotInNonEmpty -> valueIn  )).




add: newObject beforeIndex: index 
 "Add the argument, newObject, as an element of the receiver. Put it in 
 the sequence just before index. Answer newObject."

 self add: newObject afterIndex: index - 1.
 ^ newObject
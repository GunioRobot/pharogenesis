A skiplist is a sorted data structure that allows one to search for any element in o(log n) time.

It also allows one to enumerate forward to the next element. Basically, its a tree-like algorithm, except it doesn't use trees.

The implementation here is similar to a Dictionary, in that it indexes (a subclass of) Associations. Thus, you can do    foo at: key put: value   You can also search for a key, if the key does not exist, it will report the first key greater than the search, or nil.

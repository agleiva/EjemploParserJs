foo = 0;
final = 0;

if (A != 5 && (A < 10 || A > 20)) {
    throw SomethingWrongException();
} else {
    foo = 15;
}

if (B != 1 && B != 3 && B != 5 && B != 10 && B != 35) {
    throw SomethingWrongException();
} else {
    if (A > 13) {
        foo = foo / 2;
    } else {
        foo = foo + A;
    }
}

if (C > A || C == A && foo < 42) {
    throw SomethingWrongException();
} else {
    if (foo + B == 40) {
        final = foo - 1;
    } else {
        final = foo;
    }
}
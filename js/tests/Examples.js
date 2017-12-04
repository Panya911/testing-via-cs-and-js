import assert from 'assert';
import chai from 'chai';
chai.should();

class Calculator {
    constructor() {
        this._currentSum = 0;
    }

    add(number) {
        if (isNaN(number))
            throw Error;
        this._currentSum += number;
    }

    sum() {
        return this._currentSum;
    }
}

it("test", () => {
    const calc = new Calculator();
    calc.add(2);
    calc.add(2);
    const sum = calc.sum();
    assert.equal(4, sum);
});

describe("Calculator specification", () => {

    describe("add", () => {

        [
            {numbers: [1, 2], result: 3},
            {numbers: [10, 5], result: 15},
            {numbers: [1, 2, 3, 4], result: 10},
        ].forEach((x) => {
            it(`should add given number to accumulated value. ${x.numbers.join('+')}=${x.result}`, () => {
                const calculator = new Calculator();

                for (let i = 0; i < x.numbers.length; i++) {
                    calculator.add(x.numbers[i]);
                }

                const sum = calculator.sum();
                assert.equal(x.result, sum);
            });
        });

        it("should fail if NaN parameter passed", () => {
            const calc = new Calculator();

            const act = () => calc.add(NaN);

            assert.throws(act);
        });

        it("should fail if NaN parameter passed with chai", () => {
            const calc = new Calculator();

            const act = () => calc.add(NaN);

            act.should.throw();
        });
    });

    describe("sum", () => {

        it("should return zero by default", () => {
            const calc = new Calculator();

            const result = calc.sum();

            assert.equal(0, result)
        });

        it("should return zero by default with chai", () => {
            const calc = new Calculator();

            const result = calc.sum();

            result.should.be.equal(0);
        });
    })
});


describe("mocha life cycle tests", () => {
    before(() => {
        console.log("before all");
    });
    beforeEach(() => {
        console.log("before each");
    });
    afterEach(() => {
        console.log("after each");
    });
    after(() => {
        console.log("after all")
    });
    it("test1", () => {
        console.log("test1")
    });
    it("test2", () => {
        console.log("test2");
    });
});




import { TimesPipe } from './times.pipe';

describe('TimesPipe', () => {
  let timesPipe: TimesPipe;

  beforeEach(() => {
    timesPipe = new TimesPipe();
  });

  it('should create', () => {
    expect(timesPipe).toBeTruthy();
  });

  it('should return an array of length', () => {
    const length = 8;
    const result = timesPipe.transform(length);
    expect(result.length).toEqual(length);
  });
});
